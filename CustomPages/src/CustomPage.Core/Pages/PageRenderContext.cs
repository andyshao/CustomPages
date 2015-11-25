using Microsoft.AspNet.Html.Abstractions;

namespace CustomPage.Core.Pages
{
    /// <summary>
    /// ҳ����Ⱦ�����ġ�
    /// </summary>
    /// <typeparam name="T">ҳ�����͡�</typeparam>
    public abstract class PageRenderContext<T> where T : class,IPage
    {
        #region Constructor

        /// <summary>
        /// ��ʼ��һ���µ�ҳ����Ⱦ�����ġ�
        /// </summary>
        /// <param name="page">ҳ����Ϣ��</param>
        protected PageRenderContext(T page)
        {
            //            Page = page.NotNull("page");
            Page = page;
        }

        #endregion Constructor

        #region Property

        /// <summary>
        /// ҳ����Ϣ��
        /// </summary>
        public T Page { get; set; }

        /// <summary>
        /// �Ƿ���ȫ��ֹ�¼���ִ�У����Ϊ true ����ֹ������ʱ��ִ�У���
        /// </summary>
        public bool IsFinish { get; set; }

        #endregion Property

        #region Public Method

        /// <summary>
        /// ��ֹ�����¼���ִ�С�
        /// </summary>
        public void Finish()
        {
            IsFinish = true;
        }

        #endregion Public Method
    }

    /// <summary>
    /// ҳ����Ⱦǰ�����ġ�
    /// </summary>
    public class PageRenderingContext : PageRenderContext<Page>
    {
        #region Constructor

        /// <summary>
        /// ��ʼ��һ���µ�ҳ����Ⱦǰ�����ġ�
        /// </summary>
        /// <param name="page">ҳ����Ϣ��</param>
        public PageRenderingContext(Page page)
            : base(page)
        {
        }

        #endregion Constructor

        #region Property

        /// <summary>
        /// �����滻��Ⱦ��������ݡ�
        /// </summary>

        public IHtmlContent Result { get; set; }

        #endregion Property
    }

    /// <summary>
    /// ҳ����Ⱦ�������ġ�
    /// </summary>
    public class PageRenderedContext : PageRenderContext<Page>
    {
        #region Constructor

        /// <summary>
        /// ��ʼ��һ���µ�ҳ����Ⱦ�������ġ�
        /// </summary>
        /// <param name="page">ҳ����Ϣ��</param>
        /// <param name="isReplaced">��Ⱦ����Ƿ��滻��</param>

        public PageRenderedContext(Page page, bool isReplaced)
            : base(page)
        {
            IsReplaced = isReplaced;
        }

        #endregion Constructor

        /// <summary>
        /// ��Ⱦ����Ƿ��滻��
        /// </summary>
        public bool IsReplaced { get; private set; }
    }
}